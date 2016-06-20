using System;

namespace ConsoleApplication1
{
    public class ResourceHolderBase : IDisposable
    {
        public object Resources;
        protected bool _isDisposed = false;
        public virtual void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~ResourceHolderBase()
        {
            Console.WriteLine("BASE destructor");
            this.Dispose();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    if (Resources != null)
                    {
                        Console.WriteLine("BASE dispose");
                        Resources = null;
                    }
                }
            }
            _isDisposed = true;
        }

    }

    public class ResourceHolderDerived : ResourceHolderBase, IDisposable
    {
        ~ResourceHolderDerived()
        {
            Console.WriteLine("DERIVED destructor");
            this.Dispose();
        }

        public override void Dispose()
        {
            if (!_isDisposed) Console.WriteLine("DERIVED dispose");
            base.Dispose();
            GC.SuppressFinalize(this);
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            using (var resHolderBase = new ResourceHolderBase())
            {
                using (var resHolderDerived = new ResourceHolderDerived())
                {
                    resHolderBase.Resources = new int[3];
                    resHolderDerived.Resources = new int[4];
                }
                Console.WriteLine("-------------------------");
            }

            Console.WriteLine("-------------------------");
            ResourceHolderBase b = new ResourceHolderBase();
            b.Resources = new int[5];
            b.Dispose();
            b.Dispose();
            Console.WriteLine("-------------------------");
            ResourceHolderBase d = new ResourceHolderDerived();
            d.Resources = new int[5];
            d.Dispose();
            d.Dispose();

            Console.ReadLine();
        }
    }
}
