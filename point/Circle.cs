using System;

namespace PPP
{
    public class CircleObject
    {
        private PointObject m_center;
        private float m_radius;
        private float m_area;

        public const float PI = 3.1415926f;

        public CircleObject()
        {
            m_center = new PointObject(0, 0);
            m_radius = 0.0f;
            m_area = 0.0f;
        }

        public CircleObject(PointObject center, float radius)
        {
            m_center = center;
            m_radius = radius;
        }

        public float Radius
        {
            get { return m_radius; }
            set { m_radius = value; }
        }

        public float Area
        {
            get { return m_area; }
            set { m_area = value; }
        }
    }
}
