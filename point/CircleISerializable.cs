using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace PPP
{
    [Serializable]
    public class CircleObjectISer : ISerializable
    {
        private PointObject m_center;
        private float m_radius;
        private float m_area;

        public const float PI = 3.1415926f;

        public CircleObjectISer()
        {
            m_center = new PointObject(0, 0);
            m_radius = 0.0f;
            m_area = 0.0f;
        }

        public CircleObjectISer(PointObject center, float radius)
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

        public PointObject Center
        {
            get { return m_center; }
            set { m_center = value; }
        }

        // Interface implementation
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)] //! This has no effect in dotnetcore.
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("radius", m_radius);
            info.AddValue("center", m_center);
            if ((context.State & StreamingContextStates.Other) != 0) // if the steaming is other (Although I don't know in which condition I need to copy a wrong value to the serialization formatter)
            {
                info.AddValue("area", m_area);
            }
            else
            {
                //nothing to do 
            }
        }
        // special ctor for serialization
        public CircleObjectISer(SerializationInfo info, StreamingContext context)
        {
            m_radius = info.GetInt32("radius");
            m_center = (PointObject)info.GetValue("center", typeof(PointObject));
            if ((context.State & StreamingContextStates.Other) != 0)
            {
                try
                {
                    m_area = info.GetInt32("area");
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    m_area = PI * m_radius * m_radius;
                }
            }
            else
            {
                m_area = PI * m_radius * m_radius;
            }
            return;
        }
    }
}
