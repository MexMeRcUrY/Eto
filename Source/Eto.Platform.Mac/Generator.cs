using System;
using System.Runtime.InteropServices;
using Eto.Drawing;
using Eto.Forms;
using Eto.IO;
using MonoMac.AppKit;
using Eto.Platform.Mac.Drawing;
using MonoMac.CoreGraphics;
using MonoMac.Foundation;
using Eto.Platform.Mac.IO;
using System.Threading;
using SD = System.Drawing;
using Eto.Platform.Mac.Forms.Controls;
using Eto.Platform.Mac.Forms.Printing;
using Eto.Platform.Mac.Forms;
using Eto.Platform.Mac.Forms.Menu;

namespace Eto.Platform.Mac
{
	public class Generator : Eto.Generator
	{ 	
		public override string ID
		{
			get { return Generators.Mac; }
		}

		public Generator ()
		{
			AddTo(this);
		}


		public static void AddTo(Eto.Generator g)
		{
			// Drawing
			g.Add <IBitmap> (() => new BitmapHandler ());
			g.Add <IFontFamily> (() => new FontFamilyHandler ());
			g.Add <IFont> (() => new FontHandler ());
			g.Add <IFonts> (() => new FontsHandler ());
			g.Add <IGraphics> (() => new GraphicsHandler ());
			g.Add <IGraphicsPathHandler> (() => new GraphicsPathHandler ());
			g.Add <IIcon> (() => new IconHandler ());
			g.Add <IIndexedBitmap> (() => new IndexedBitmapHandler ());
			g.Add <IMatrixHandler> (() => new MatrixHandler ());
			g.Add <IPen> (() => new PenHandler ());
			g.Add <ISolidBrush> (() => new SolidBrushHandler ());
			g.Add <ITextureBrush> (() => new TextureBrushHandler ());
			g.Add<ILinearGradientBrush> (() => new LinearGradientBrushHandler ());

			// Forms.Cells
			g.Add <ICheckBoxCell> (() => new CheckBoxCellHandler ());
			g.Add <IComboBoxCell> (() => new ComboBoxCellHandler ());
			g.Add <IImageTextCell> (() => new ImageTextCellHandler ());
			g.Add <IImageViewCell> (() => new ImageViewCellHandler ());
			g.Add <ITextBoxCell> (() => new TextBoxCellHandler ());
			
			// Forms.Controls
			g.Add <IButton> (() => new ButtonHandler ());
			g.Add <ICheckBox> (() => new CheckBoxHandler ());
			g.Add <IComboBox> (() => new ComboBoxHandler ());
			g.Add <IDateTimePicker> (() => new DateTimePickerHandler ());
			g.Add <IDrawable> (() => new DrawableHandler ());
			g.Add <IGridColumn> (() => new GridColumnHandler ());
			g.Add <IGridView> (() => new GridViewHandler ());
			g.Add <IGroupBox> (() => new GroupBoxHandler ());
			g.Add <IImageView> (() => new ImageViewHandler ());
			g.Add <ILabel> (() => new LabelHandler ());
			g.Add <IListBox> (() => new ListBoxHandler ());
			g.Add <INumericUpDown> (() => new NumericUpDownHandler ());
			g.Add <IPanel> (() => new PanelHandler ());
			g.Add <IPasswordBox> (() => new PasswordBoxHandler ());
			g.Add <IProgressBar> (() => new ProgressBarHandler ());
			g.Add <IRadioButton> (() => new RadioButtonHandler ());
			g.Add <IScrollable> (() => new ScrollableHandler ());
			g.Add <ISlider> (() => new SliderHandler ());
			g.Add <ISplitter> (() => new SplitterHandler ());
			g.Add <ITabControl> (() => new TabControlHandler ());
			g.Add <ITabPage> (() => new TabPageHandler ());
			g.Add <ITextArea> (() => new TextAreaHandler ());
			g.Add <ITextBox> (() => new TextBoxHandler ());
			g.Add <ITreeGridView> (() => new TreeGridViewHandler ());
			g.Add <ITreeView> (() => new TreeViewHandler ());
			g.Add <IWebView> (() => new WebViewHandler ());
			
			// Forms.Menu
			g.Add <ICheckMenuItem> (() => new CheckMenuItemHandler ());
			g.Add <IContextMenu> (() => new ContextMenuHandler ());
			g.Add <IImageMenuItem> (() => new ImageMenuItemHandler ());
			g.Add <IMenuBar> (() => new MenuBarHandler ());
			g.Add <IRadioMenuItem> (() => new RadioMenuItemHandler ());
			g.Add <ISeparatorMenuItem> (() => new SeparatorMenuItemHandler ());
			
			// Forms.Printing
			g.Add <IPrintDialog> (() => new PrintDialogHandler ());
			g.Add <IPrintDocument> (() => new PrintDocumentHandler ());
			g.Add <IPrintSettings> (() => new PrintSettingsHandler ());
			
			// Forms.ToolBar
			g.Add <ICheckToolBarButton> (() => new CheckToolBarButtonHandler ());
			g.Add <ISeparatorToolBarItem> (() => new SeparatorToolBarItemHandler ());
			g.Add <IToolBarButton> (() => new ToolBarButtonHandler ());
			g.Add <IToolBar> (() => new ToolBarHandler ());
			
			// Forms
			g.Add <IApplication> (() => new ApplicationHandler ());
			g.Add <IClipboard> (() => new ClipboardHandler ());
			g.Add <IColorDialog> (() => new ColorDialogHandler ());
			g.Add <ICursor> (() => new CursorHandler ());
			g.Add <IDialog> (() => new DialogHandler ());
			g.Add <IDockLayout> (() => new DockLayoutHandler ());
			g.Add <IFontDialog> (() => new FontDialogHandler ());
			g.Add <IForm> (() => new FormHandler ());
			g.Add <IMessageBox> (() => new MessageBoxHandler ());
			g.Add <IOpenFileDialog> (() => new OpenFileDialogHandler ());
			g.Add <IPixelLayout> (() => new PixelLayoutHandler ());
			g.Add <ISaveFileDialog> (() => new SaveFileDialogHandler ());
			g.Add <ISelectFolderDialog> (() => new SelectFolderDialogHandler ());
			g.Add <ITableLayout> (() => new TableLayoutHandler ());
			g.Add <IUITimer> (() => new UITimerHandler ());
			
			// IO
			g.Add <ISystemIcons> (() => new SystemIconsHandler ());

			// General
			g.Add <IEtoEnvironment> (() => new EtoEnvironmentHandler ());
		}

		public override IDisposable ThreadStart ()
		{
			return new NSAutoreleasePool ();
		}
        public static RectangleF Convert(System.Drawing.RectangleF rect)
        {
            return new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
        }

		
        public static System.Drawing.RectangleF Convert(RectangleF rect)
        {
            return new System.Drawing.RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
        }
		
        public static System.Drawing.PointF Convert(PointF point)
        {
            return new System.Drawing.PointF(point.X, point.Y);
        }

        public static PointF Convert(System.Drawing.PointF point)
        {
            return new PointF(point.X, point.Y);
        }
		
        internal static SD.PointF[] Convert(PointF[] points)
        {
            var result =
                new SD.PointF[points.Length];

            for (var i = 0;
                i < points.Length;
                ++i)
            {
                var p = points[i];
                result[i] =
                    new SD.PointF(p.X, p.Y);
            }

            return result;
        }

#if FIX
		internal static Matrix Convert(
	CGAffineTransform t)
		{
			return Matrix.Create(
				t.xx,
				t.yx,
				t.xy,
				t.yy,
				t.x0,
				t.y0);
		}

#endif
    }
}
