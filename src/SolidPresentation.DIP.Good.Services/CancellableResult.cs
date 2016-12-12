namespace SolidPresentation.DIP.Good.Services
{
    using System;

    public class CancellableResult<T>
    {
        private bool isSuccess;
        private T obj;

        private CancellableResult()
        {
        }

        public bool IsSuccess => this.isSuccess;
        public bool IsCancelled => !this.isSuccess;

        public T Object
        {
            get
            {
                if (this.IsCancelled)
                {
                    throw new InvalidOperationException("Window has been cancelled");
                }

                return this.obj;
            }
        }

        public static CancellableResult<T> Success(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            var successObj = new CancellableResult<T>();
            successObj.obj = obj;
            successObj.isSuccess = true;
            return successObj;
        }

        public static CancellableResult<T> Cancel()
        {
            var cancelObj = new CancellableResult<T>();
            cancelObj.isSuccess = false;
            return cancelObj;
        }
    }
}
