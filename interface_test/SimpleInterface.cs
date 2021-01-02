using System;

namespace interface_test
{
    public interface ISimpleInterface
    {
        // public SimpleInterface(){} //! interface can not has ctor
        // public Int32 someField = 1000; //! interface can not has field;

        public Int32 Data // 就是这样
        {
            get;
            set;
        }

        public void SomeInterfaceMethod(); // if the method has the default implementation, the class inherit it doesn't have to. But if not, it has to.

    }

    public interface ISimpleDerviedInterface : ISimpleInterface
    {
        // 接口继承接口是ok的，应该是标准继承逻辑
    }

    internal interface IMissileComponent
    {
        void Fire();
    }
    internal interface ILaserComponent
    {
        void Fire();
    }
    internal interface IBulletComponent
    {
        void Fire();
    }
    internal class HomemadeWeapon : IMissileComponent, ILaserComponent, IBulletComponent
    {
        void IMissileComponent.Fire()
        {
            System.Console.WriteLine("FireMissile!");
        }
        void ILaserComponent.Fire()
        {
            System.Console.WriteLine("FireLaser!");
        }
        public void Fire()
        {
            System.Console.WriteLine("BulletFire!");
        }
    }
}
