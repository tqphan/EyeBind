using System;
using System.Windows.Forms;
using System.Drawing;
using System.Timers;
using WindowsInput;
using EyeBind.Properties;

namespace EyeBind
{
    public static class MouseMover
    {
        private static InputSimulator inputSimulator = new InputSimulator();

        private static System.Timers.Timer timer = new System.Timers.Timer(33);

        private static PointD current = new PointD();
        private static PointD destination = new PointD();

        private static Rectangle innerRect = new Rectangle(new Point(), new Size(200, 200));
        private static Rectangle middleRect = new Rectangle(new Point(), new Size(400, 400));
        private static Rectangle outerRect = new Rectangle(new Point(), new Size(600, 600));

        private static float innerRectScale = 0.15F;
        private static float middleRectScale = 0.25F;
        private static float outerRectScale = 0.50F;

        private static int innerSpeed = 0;
        private static int middleSpeed = 0;
        private static int outerSpeed = 0;
        private static int maxSpeed = 0;

        static MouseMover()
        {
            CalculateFirstPersonSpeed(Settings.Default.MouseMoveFirstPersonSpeed, Settings.Default.MouseMoveFirstPersonSpeedMultiplier);
        }

        public static int Speed
        {
            get
            {
                return Settings.Default.MouseMoveFirstPersonSpeed;
            }
            set
            {
                if (value != Settings.Default.MouseMoveFirstPersonSpeed)
                {
                    Settings.Default.MouseMoveFirstPersonSpeed = value;
                    CalculateFirstPersonSpeed(value, Settings.Default.MouseMoveFirstPersonSpeedMultiplier);
                }
            }
        }

        public static int Acceleration
        {
            get
            {
                return Settings.Default.MouseMoveFirstPersonSpeedMultiplier;
            }
            set
            {
                if (value != Settings.Default.MouseMoveFirstPersonSpeedMultiplier)
                {
                    Settings.Default.MouseMoveFirstPersonSpeedMultiplier = value;
                    CalculateFirstPersonSpeed(Settings.Default.MouseMoveFirstPersonSpeed, value);
                }
            }
        }

        private static int followSpeed = Settings.Default.MouseMoveFollowSpeed;

        public static int FollowSpeed
        {
            get
            {
                return Settings.Default.MouseMoveFollowSpeed;
            }
            set
            {
                if (value != followSpeed)
                {
                    followSpeed = value;
                    Settings.Default.MouseMoveFollowSpeed = value;
                }
            }
        }

        private static MouseMoveMode mode = Settings.Default.MouseMoveMode;

        public static MouseMoveMode Mode
        {
            get
            {
                return Settings.Default.MouseMoveMode;
            }
            set
            {
                if (value != mode)
                {
                    mode = value;
                    Settings.Default.MouseMoveMode = value;
                }
            }
        }

        private static bool enabled;
        public static bool Enabled
        {
            get
            {
                return enabled;
            }
            set
            {
                if (value != enabled)
                {
                    enabled = value;
                    if (value)
                    {

                        Program.FixationDataStream.Next -= FixationDataStream_Next;
                        Program.FixationDataStream.Next += FixationDataStream_Next;

                        Program.EyeXHost.ScreenBoundsChanged -= EyeXHost_ScreenBoundsChanged;
                        Program.EyeXHost.ScreenBoundsChanged += EyeXHost_ScreenBoundsChanged;
                    }
                    else
                    {
                        Program.FixationDataStream.Next -= FixationDataStream_Next;
                        Program.EyeXHost.ScreenBoundsChanged -= EyeXHost_ScreenBoundsChanged;
                    }
                }
            }
        }

        private static bool continuousMouseMoveEnabled;

        public static bool ContinuousMouseMoveEnabled
        {
            get
            {
                return continuousMouseMoveEnabled;
            }
            set
            {
                if (value != continuousMouseMoveEnabled)
                {
                    continuousMouseMoveEnabled = value;
                    if (value)
                    {
                        PositionRectangles();
                        timer.Elapsed += timer_Elapsed;
                        timer.Enabled = true;
                    }
                    else
                    {
                        timer.Enabled = false;
                        timer.Elapsed -= timer_Elapsed;
                    }
                }
            }
        }

        private static int stopDistance = Settings.Default.MouseMoveStopDistance;

        public static int StopDistance
        {
            get
            {
                return Settings.Default.MouseMoveStopDistance;
            }
            set
            {
                if (value != stopDistance)
                {
                    stopDistance = value;
                    Settings.Default.MouseMoveStopDistance = value;
                }
            }
        }

        private static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            switch(mode)
            {
                case MouseMoveMode.WarpToGazePoint:
                    OnWarpToGazePoint();
                    break;
                case MouseMoveMode.FollowGazePoint:
                    OnFollowGazePoint();
                    break;
                case MouseMoveMode.FirstPersonShooter:
                    OnFirstPerson();
                    break;

            }
        }

        private static void OnFirstPerson()
        {
            int speed = GetCurrentSpeed();
            if (speed > 0)
            {
                double x = 0;
                double y = 0;
                inputSimulator.Mouse.GetMousePosition(ref x, ref y);

                PointD p = MovePointTowards(new PointD(x, y), destination, speed);

                if (IsWithinPrimaryScreenBound(p))
                    inputSimulator.Mouse.MoveMouseTo(p.X, p.Y);
            }
        }

        private static void OnFollowGazePoint()
        {
            double x = 0;
            double y = 0;
            inputSimulator.Mouse.GetMousePosition(ref x, ref y);
            PointD p = MovePointTowards(new PointD(x, y), destination, followSpeed);
            inputSimulator.Mouse.MoveMouseTo(p.X, p.Y);
        }

        private static void OnWarpToGazePoint()
        {
            double x = 0;
            double y = 0;
            inputSimulator.Mouse.GetMousePosition(ref x, ref y);
            PointD currentMousePossition = new PointD(x, y);
            if(!IsWithinStopDistance(currentMousePossition, destination, stopDistance))
                inputSimulator.Mouse.MoveMouseTo(destination.X, destination.Y);
        }

        private static void EyeXHost_ScreenBoundsChanged(object sender, EyeXFramework.EngineStateValue<Tobii.EyeX.Client.Rect> e)
        {
            PositionRectangles();
        }

        private static void FixationDataStream_Next(object sender, EyeXFramework.FixationEventArgs e)
        {
            destination = new PointD(e.X, e.Y);
        }

        private static void CalculateFirstPersonSpeed(int speed, int acceleration)
        {
            innerSpeed = 0;
            middleSpeed = speed;
            outerSpeed = speed * acceleration;
            maxSpeed = speed * acceleration * acceleration;
        }

        private static void PositionRectangles()
        {
            ScaleRectangle(ref innerRect, innerRectScale);
            ScaleRectangle(ref middleRect, middleRectScale);
            ScaleRectangle(ref outerRect, outerRectScale);
            CenterRectangle(ref innerRect);
            CenterRectangle(ref middleRect);
            CenterRectangle(ref outerRect);
        }

        private static PointD MovePointTowards(PointD source, PointD destination, int distance)
        {
            if (source == destination)
                return destination;

            PointD vector = new PointD(destination.X - source.X, destination.Y - source.Y);
            double length = Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);

            if (length < distance)
                return destination;

            PointD unitVector = new PointD(vector.X / length, vector.Y / length);
            return new PointD(source.X + unitVector.X * distance, source.Y + unitVector.Y * distance);
        }

        private static void ScaleRectangle(ref Rectangle rect, float scale)
        {
            rect.Width = (int)(Screen.PrimaryScreen.Bounds.Width * scale);
            rect.Height = (int)(Screen.PrimaryScreen.Bounds.Height * scale);
        }

        private static void CenterRectangle(ref Rectangle rect)
        {
            rect.X = (Screen.PrimaryScreen.Bounds.Width - rect.Width) / 2;
            rect.Y = (Screen.PrimaryScreen.Bounds.Height - rect.Height) / 2;
        }

        private static int GetCurrentSpeed()
        {
            Point point = new Point((int)destination.X, (int)destination.Y);

            if (innerRect.Contains(point))
                return innerSpeed;

            if (middleRect.Contains(point))
                return middleSpeed;

            if (outerRect.Contains(point))
                return outerSpeed;

            return maxSpeed;
        }

        private static bool IsWithinPrimaryScreenBound(PointD p)
        {
            return ((int)Math.Truncate(p.X) >= 0 && (int)Math.Truncate(p.X) <= Screen.PrimaryScreen.Bounds.Width &&
                    (int)Math.Truncate(p.Y) >= 0 && (int)Math.Truncate(p.Y) <= Screen.PrimaryScreen.Bounds.Height);
        }

        private static bool IsWithinStopDistance(PointD p1, PointD p2, int distance)
        {
            PointD vector = new PointD(p1.X - p2.X, p1.Y - p2.Y);
            double length = Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if ((int)Math.Truncate(length) < distance)
                return true;
            else
                return false;
        }

        public static void MoveMouse()
        {
            inputSimulator.Mouse.MoveMouseTo(destination.X, destination.Y);
        }
    }
}
