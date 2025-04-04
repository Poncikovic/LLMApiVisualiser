using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLMApiVisualiser
{
    internal class PromptEvent
    {
        public string Role { get; set; }
        public string Text { get; set; }
        public PromptEvent(string role, string text)
        {
            Role = role;
            Text = text;
        }
        public PromptEvent(PromptEvent promptEvent)
        {
            Role = promptEvent.Role;
            Text = promptEvent.Text;
        }


        public override string ToString()
        {
            return Role;
        }


    }
}
