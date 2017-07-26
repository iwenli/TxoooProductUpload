using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TxoooProductUpload.UI
{
    /// <summary>
    /// 带水印的TextBox
    /// </summary>
    public partial class WatermakRichTextBox : RichTextBox
    {
        private const int WM_PAINT = 0xF;
        string _emptyTextTip = "请输入内容";
        Color _emptyTextTipColor = Color.DarkGray;

        /// <summary>
        /// 水印文本
        /// </summary>
        public string EmptyTextTip { set { _emptyTextTip = value; } get { return _emptyTextTip; } }

        /// <summary>
        /// 水印颜色
        /// </summary>
        public Color EmptyTextTipColor { set { _emptyTextTipColor = value; } get { return _emptyTextTipColor; } }

        public WatermakRichTextBox():base()
        {
            InitializeComponent();
        }

        public WatermakRichTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_PAINT)
            {
                WmPaint(ref m);
            }
        }
        private void WmPaint(ref Message m)
        {
            Rectangle rectangle = new Rectangle(0, 0, Width, Height);
            using (Graphics graphics = Graphics.FromHwnd(base.Handle))
            {
                if (Text.Length == 0
                   && !string.IsNullOrEmpty(_emptyTextTip)
                   && !Focused)
                {
                    TextFormatFlags format = TextFormatFlags.EndEllipsis | TextFormatFlags.VerticalCenter;
                    if (RightToLeft == RightToLeft.Yes)
                    {
                        format |= TextFormatFlags.RightToLeft | TextFormatFlags.Right;
                    }
                    TextRenderer.DrawText(
                        graphics,
                        _emptyTextTip,
                        Font,
                        base.ClientRectangle,
                        _emptyTextTipColor,
                        format);
                }
            }
        }
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            base.Invalidate();
        }
        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            base.Invalidate();
        }
    }
}
