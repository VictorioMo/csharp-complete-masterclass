using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroGenerics
{
    // Generic class:
    public class Box<T>
    {
        private T _content;

        public Box(T content)
        {
            _content = content;
        }

        public void UpdateContent(T newContent)
        {
            _content = newContent;
        }

        public T GetContent()
        {
            return _content;
        }

        public string Log()
        {
            return $"Box contains {_content}";
        }
    }

    public class SmartBox<T1, T2>
    {
        private T1 _contentOfT1;
        private T2 _contentOfT2;

        public SmartBox(T1 contentOfT1, T2 contentOfT2)
        {
            _contentOfT1 = contentOfT1;
            _contentOfT2 = contentOfT2;
        }

        public void Display()
        {
            Console.WriteLine($"SmartBox contains: {_contentOfT1} and {_contentOfT2}");
        }
    }
}
