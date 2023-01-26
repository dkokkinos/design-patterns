using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    public abstract class Content
    {
        public void Render()
        {
            Initialize();
            OnInit();
            AfterContentInit();
            RenderContent();
            AfterRender();
        }

        // A required method for the render algorithm.
        private void Initialize() { /* make the proper initializations. */ }

        // hook method, runs after initialization of all properties of the component.
        // Override this method to handle any additional initialization tasks.
        protected virtual void OnInit() { }

        // hook method, runs after content is fully initialized and validated.
        private void AfterContentInit() { }

        // A required method actually renders the contents.
        private void RenderContent() { /* rendering. */ }

        // hook method, is called after the component has completed rendering all content.
        private void AfterRender() { }
    }
}
