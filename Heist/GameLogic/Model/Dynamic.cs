using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic.Model
{
    public struct WayPoint
    {
        public double targetX, targetY, accel;

        public WayPoint(double targetX_, double targetY_, double accel_) 
        {
            targetX = targetX_;
            targetY = targetY_;
            accel = accel_;
        }
    }

    public abstract class Dynamic : Entity
    {
        public double accel;

        public Queue<WayPoint> wayPoints;

        public Dynamic(string texName, int id, double x, double y, double accel_, double targetX_, double targetY_)
            : base(texName, id, x, y)
        {
            wayPoints = new Queue<WayPoint>();
            accel = accel_;
            wayPoints.Enqueue(new WayPoint(accel, x, y));
        }

        public Dynamic(string texName, int id, double x, double y, double accel_)
            : base(texName, id, x, y)
        {
            wayPoints = new Queue<WayPoint>();
            accel = accel_;
        }

        public Dynamic(string texName, int id, double x, double y)
            : base(texName, id, x, y)
        {
            wayPoints = new Queue<WayPoint>();
            accel = 0;
        }
    }
}
