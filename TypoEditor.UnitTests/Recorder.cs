using System;
using System.Collections.Generic;
using System.Reflection;

namespace TypoEditor.UnitTests
{
    public class Recorder<T> where T : class
    {
        private List<InvocationRecord> records;

        public Recorder()
        {
            this.records = new List<InvocationRecord>();
        }

        public void Record(Action<T> action, object result = null)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }
            T proxy = DispatchProxy.Create<T, RecordingProxy>();
            object dummy = (object)proxy;
            RecordingProxy instance = (RecordingProxy)dummy;
            instance.records = records;
            instance.result = result;
            action(proxy);
        }

        public T Replay()
        {
            T proxy = DispatchProxy.Create<T, ReplayProxy>();
            object dummy = (object)proxy;
            ReplayProxy instance = (ReplayProxy)dummy;
            instance.records = records;
            return proxy;
        }

        public class RecordingProxy : DispatchProxy
        {
            public List<InvocationRecord> records;
            public object result;

            protected override object Invoke(MethodInfo targetMethod, object[] args)
            {
                this.records.Add(new InvocationRecord()
                {
                    TargetMethod = targetMethod,
                    Args = args,
                    Result = result
                });
                return result;
            }
        }

        public class ReplayProxy : DispatchProxy
        {
            public List<InvocationRecord> records;
            private int next;

            protected override object Invoke(MethodInfo targetMethod, object[] args)
            {
                // TODO: Better error reporting
                if (!targetMethod.Equals(this.records[this.next].TargetMethod))
                {
                    throw new InvalidOperationException();
                }
                if (args.Length != this.records[this.next].Args.Length)
                {
                    throw new InvalidOperationException();
                }
                for (int i = 0; i < args.Length; i++)
                {
                    if (!args[i].Equals(this.records[this.next].Args[i]))
                    {
                        // We cannot perform the validation because 41a01ea348c4
                        // throw new InvalidOperationException();
                    }
                }
                return this.records[this.next++].Result;
            }
        }

        public struct InvocationRecord
        {
            public MethodInfo TargetMethod;
            public object[] Args;
            public object Result;
        }
    }
}
