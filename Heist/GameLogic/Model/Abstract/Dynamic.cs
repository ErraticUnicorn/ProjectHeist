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
        public double maxSpeed;

        private Queue<WayPoint> wayPoints;

        public Dynamic(string texName, int id, double x, double y, double maxSpeed_)
            : base(texName, id, x, y)
        {
            wayPoints = new Queue<WayPoint>();
            maxSpeed = maxSpeed_;
        }

        public Dynamic(string texName, int id, double x, double y)
            : base(texName, id, x, y)
        {
            wayPoints = new Queue<WayPoint>();
            maxSpeed = 0;
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
            return wayPoints.Dequeue();
        }

        public void AppendWayPoint(WayPoint w)
        {
            wayPoints.Enqueue(w);
        }

        public void ClearWayPoints()
        {
            wayPoints.Clear();
        }

        public void SetWayPoint(WayPoint w)
        {
            ClearWayPoints();
            AppendWayPoint(w);
        }

    }
}
