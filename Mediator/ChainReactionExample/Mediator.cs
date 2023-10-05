namespace Mediator.ChainReactionExample
{
    public class Mediator
    {
        public DropDown DropDown;
        public Button Button;
        public TextBox TextBox;
        public FontEditor FontEditor;

        public Mediator()
        {
            DropDown = new DropDown(this);
            Button = new Button(this);
            TextBox = new TextBox(this);
            FontEditor = new FontEditor(this);
        }

        public void StateChanged(Participant participant)
        {
            if (participant == TextBox && TextBox.IsEnabled)
            {
                FontEditor.Enable();
                return;
            }

            if (participant == TextBox && !TextBox.IsEnabled)
            {
                FontEditor.Disable();
                return;
            }

            if (participant == DropDown && DropDown.SelectedItem == "Manual")
            {
                Button.Enable();
                TextBox.Enable();
                return;
            }

            if (participant == DropDown && DropDown.SelectedItem == "Auto")
            {
                Button.Disable();
                TextBox.Disable();
                return;
            }
        }
    }
}
