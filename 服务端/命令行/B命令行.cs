using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 系统管理.服务端
{
    class B命令行
    {
        Dictionary<string, Process> _进程缓存 = new Dictionary<string, Process>();

        public bool IsWindows { get; private set; }

        public B命令行()
        {
            IsWindows = Program.IsWindows;
        }

        public void 创建进程(string __进程标识)
        {
            if (_进程缓存.ContainsKey(__进程标识))
            {
                _进程缓存[__进程标识].Kill();
            }
            var __进程 = new Process();
            if (IsWindows)
            {
                __进程.StartInfo.FileName = "cmd";
            }
            else
            {
                __进程.StartInfo.FileName = "sh";
            }
            __进程.StartInfo.UseShellExecute = false;
            __进程.StartInfo.RedirectStandardInput = true;
            __进程.StartInfo.RedirectStandardOutput = true;
            __进程.StartInfo.RedirectStandardError = true;
            __进程.StartInfo.CreateNoWindow = true;
            __进程.EnableRaisingEvents = true;
            __进程.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
            {
                on异常输出(new M输出 { 内容 = e.Data, 进程标识 = __进程标识 });
            };
            __进程.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
            {
                on正常输出(new M输出 { 内容 = e.Data, 进程标识 = __进程标识 });
            };
            __进程.Exited += (object sender, EventArgs e) =>
            {
                on执行结束(new M输出 { 进程标识 = __进程标识 });
            };
            __进程.Start();
            __进程.BeginOutputReadLine();
            __进程.BeginErrorReadLine();

            _进程缓存[__进程标识] = __进程;

        }

        public void 结束进程(string __进程标识)
        {
            if (_进程缓存.ContainsKey(__进程标识))
            {
                _进程缓存[__进程标识].Kill();
                _进程缓存[__进程标识].Dispose();
                _进程缓存.Remove(__进程标识);
            }
        }

        public void 执行(string __进程标识, List<string> __命令行列表)
        {
            if (_进程缓存.ContainsKey(__进程标识))
            {
                var __进程 = _进程缓存[__进程标识];
                foreach (var item in __命令行列表)
                {
                    __进程.StandardInput.WriteLine(item);
                }
            }
        }

        public event Action<M输出> 正常输出;

        public void on正常输出(M输出 __参数)
        {
            正常输出?.Invoke(__参数);
        }

        public event Action<M输出> 异常输出;

        public void on异常输出(M输出 __参数)
        {
            异常输出?.Invoke(__参数);
        }

        public event Action<M输出> 执行结束;

        public void on执行结束(M输出 __参数)
        {
            执行结束?.Invoke(__参数);
        }

    }
}
