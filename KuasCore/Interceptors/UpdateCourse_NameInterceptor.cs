using AopAlliance.Intercept;
using KuasCore.Models;
using System;
using System.Diagnostics;

namespace KuasCore.Interceptors 
{
    class UpdateCourse_NameInterceptor : IMethodInterceptor
    {

        public object Invoke(IMethodInvocation invocation)
        {

            Console.WriteLine("UpdateCourse_NameInterceptor 攔截到一個方法呼叫 = [{0}]", invocation);
            Debug.Print("UpdateCourse_NameInterceptor 攔截到一個方法呼叫 = [{0}]", invocation);

            object result = invocation.Proceed();

            if (result is Course)
            {
                Course Course = (Course)result;
                Course.Course_Name = Course.Course_Name + " 加入AOP加入";
                result = Course;
            }

            return result;
        }
    }
}
