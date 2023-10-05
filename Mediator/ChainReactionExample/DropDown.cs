using System;
using System.Collections.Generic;
using System.Linq;

namespace Mediator.ChainReactionExample
{
    public class DropDown : Participant
    {
        private readonly Dictionary<string, bool> items;

        public DropDown(Mediator mediator)
            : base(mediator)
        {
            items = new Dictionary<string, bool>()
             {
                 {"Auto", false },
                 {"Manual", false }
             };
        }

        public string SelectedItem => items.FirstOrDefault(x => x.Value).Key;

        public void SelectValue(string value)
        {
            var selected = items.FirstOrDefault(x => x.Value).Key;
            if (selected != null)
                items[selected] = false;

            items[value] = true;
            Console.WriteLine("DropDown value changed to: " + value);
            Mediator.StateChanged(this);
        }

    }
}
