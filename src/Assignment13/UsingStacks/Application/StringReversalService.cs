using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingStacks.Application
{
    public class StringReversalService : IReversalService<char>
    {
        private IStackService<char> _stackService;

        public StringReversalService(IStackService<char> stackService)
        {
            this._stackService = stackService;
        }

        public string Reverse(string orignalString)
        {
            var charaterStack = this.PushToStack(orignalString);
            return this.PopFromStack(charaterStack);
        }

        public string PopFromStack(StackService<char> charaterStack)
        {
            var sb = new StringBuilder(string.Empty);
            while (charaterStack.Count > 0)
            {
                char character = charaterStack.Pop();
                sb.Append(character);
            }

            return sb.ToString();
        }

        public StackService<char> PushToStack(string orignalString)
        {
            var stack = new StackService<char>();
            foreach (char charater in orignalString)
            {
                stack.Push(charater);
            }

            return stack;
        }
    }
}
