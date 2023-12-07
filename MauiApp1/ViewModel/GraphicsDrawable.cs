using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModel
{   public class GraphicsDrawable : ViewModelBase, IDrawable
    {
        List<GraphicItem> _ItemsSource;
        public List<GraphicItem> ItemsSource
        {

            get
            {
                return _ItemsSource;
            }
            set
            {
                _ItemsSource = value;
                OnPropertyChanged(() => ItemsSource);
            }
        }
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {

            PathF path = new PathF();
            path.MoveTo(40, 10);
            path.LineTo(70, 80);
            path.LineTo(10, 50);
            path.Close();
            canvas.StrokeColor = Colors.Green;
            canvas.StrokeSize = 6;
            canvas.DrawPath(path);

        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
