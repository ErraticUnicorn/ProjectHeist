using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameLogic.Model.Abstract
{
    public class WayPoint
    {
        public double targetX, targetY, speed;

        public WayPoint(double targetX_, double targetY_, double speed_) 
        {
            targetX = targetX_;
            targetY = targetY_;
            speed = speed_;
        }
    }

    public abstract class Dynamic : Control
    {
        public double maxSpeed, speed, accel, xDir, yDir;

        private Queue<WayPoint> wayPoints;

        public Dynamic() : base()
        {
            wayPoints = new Queue<WayPoint>();
            maxSpeed = 0;
            accel = 0;
        }

        public WayPoint GetNextPoint()
        {
            if(wayPoints.Count == 0) {
                return null;
            }

            return wayPoints.Peek();
        }

        public WayPoint RemoveNextPoint()
        {
            xDir = 0;
            yDir = 0;
            return wayPoints.Dequeue();
        }

        public void AppendWayPoint(WayPoint w)
        {
            wayPoints.Enqueue(w);
        }

        public void ClearWayPoints()
        {
            xDir = 0;
            yDir = 0;
            wayPoints.Clear();
        }

        public void SetWayPoint(WayPoint w)
        {
            ClearWayPoints();
            AppendWayPoint(w);
        }

    }
}
