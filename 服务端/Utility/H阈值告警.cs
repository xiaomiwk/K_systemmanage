using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility.模式
{
    class H阈值告警<T>
    {
        public T 阈值 { get; set; }

        Func<T, T, int> _比较;

        Action<bool, List<T>> _告警处理;

        public int 缓存次数 { get; set; }

        public int 告警判定次数 { get; set; }

        Queue<T> _缓存 = new Queue<T>();

        bool _告警中;

        public H阈值告警(T __阈值, Func<T, T, int> __比较, Action<bool, List<T>> __告警处理, int __缓存次数, int __告警判定次数)
        {
            阈值 = __阈值;
            _比较 = __比较;
            _告警处理 = __告警处理;
            缓存次数 = __缓存次数;
            告警判定次数 = __告警判定次数;
        }

        public void 添加(T __值)
        {
            _缓存.Enqueue(__值);
            var __旧 = _告警中;
            if (_缓存.Count > 缓存次数)
            {
                _缓存.Dequeue();
            }
            if (_缓存.Count >= 告警判定次数)
            {
                _告警中 = _缓存.Count(q => _比较(q, 阈值) >= 0) >= 告警判定次数;
            }
            if (_告警中 != __旧)
            {
                _告警处理(_告警中, _缓存.ToList());
            }
        }

        public void 添加(List<T> __值列表)
        {
            __值列表.ForEach(q => 添加(q));
        }

        public void 清除()
        {
            _缓存.Clear();
        }

        public Queue<T> 缓存 { get { return new Queue<T>(_缓存); } }
    }
}
