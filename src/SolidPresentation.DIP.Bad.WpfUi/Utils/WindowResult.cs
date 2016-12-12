namespace SolidPresentation.DIP.Bad.WpfUi.Utils
{
    using System;

    public class ClosableWindowResult<T>
    {
        private bool isSuccess;
        private T obj;

        private ClosableWindowResult()
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

        public static ClosableWindowResult<T> Success(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            var successObj = new ClosableWindowResult<T>();
            successObj.obj = obj;
            successObj.isSuccess = true;
            return successObj;
        }

        public static ClosableWindowResult<T> Cancel()
        {
            var cancelObj = new ClosableWindowResult<T>();
            cancelObj.isSuccess = false;
            return cancelObj;
        }
    }
}
