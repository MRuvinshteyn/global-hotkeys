using Gma.System.MouseKeyHook;
using System.Text;
using WindowsInput;
using WindowsInput.Native;

namespace GlobalTextExpansion
{
    public class TextExpander
    {
        private IKeyboardMouseEvents _keyboardEvents;
        private StringBuilder _typedBuffer = new StringBuilder();
        private readonly Dictionary<string, string> _templates;
        private bool _suppressNextSpace = false;

        public bool IsRunning { get; private set; }

        public TextExpander(Dictionary<string, string> templates = null)
        {
            _templates = templates ?? new Dictionary<string, string>
            {
                { ";;user1", "Username 1" },
                { ";;pass1", "Password 1" },
                { ";;user2", "Username 2" },
                { ";;pass2", "Password 2" }
            };
        }

        public void Start()
        {
            if (IsRunning) return;

            _keyboardEvents = Hook.GlobalEvents();
            _keyboardEvents.KeyPress += OnKeyPress;
            _keyboardEvents.KeyDown += OnKeyDown;
            IsRunning = true;
        }

        public void Stop()
        {
            if (!IsRunning) return;

            _keyboardEvents.KeyPress -= OnKeyPress;
            _keyboardEvents.KeyDown -= OnKeyDown;
            _keyboardEvents.Dispose();
            IsRunning = false;
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            // Whitespace might be suppressed if replacing a string
            if (_suppressNextSpace && (e.KeyChar == ' ' || e.KeyChar == '\t' || e.KeyChar == '\r'))
            {
                e.Handled = true; // Suppress whitespace key
                _suppressNextSpace = false;
                return;
            }

            // Update buffer when a character is entered (typed) or removed (via backspace)
            if (char.IsLetterOrDigit(e.KeyChar) || char.IsPunctuation(e.KeyChar))
            {
                _typedBuffer.Append(e.KeyChar);
            }
            else if (e.KeyChar == '\b' && _typedBuffer.Length > 0)
            {
                _typedBuffer.Remove(_typedBuffer.Length - 1, 1);
            }

            System.Diagnostics.Debug.WriteLine(_typedBuffer);
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space || e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                // If the string is replaced, suppress the whitespace key that triggered this check
                if (CheckString())
                {
                    _suppressNextSpace = true;
                    e.SuppressKeyPress = true; // Prevent key from being pressed
                }
            }
        }

        private bool CheckString()
        {
            string typedText = _typedBuffer.ToString();
            if (_templates.TryGetValue(typedText, out string? value))
            {
                ReplaceString(typedText, value);
                _typedBuffer.Clear();
                return true;
            }
            _typedBuffer.Clear();
            return false;
        }

        private void ReplaceString(string template, string replacementText)
        {
            var sim = new InputSimulator();

            // Simulate backspaces to erase the typed string
            for (int i = 0; i < template.Length; i++)
            {
                sim.Keyboard.KeyPress(VirtualKeyCode.BACK);
            }

            // Simulate typing the replacement text
            sim.Keyboard.TextEntry(replacementText);
        }
    }
}
