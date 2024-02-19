namespace HappyDogsV2.GraphicResources;
    public abstract class BaseDrawable : IDrawable
    {
        public abstract void Draw(ICanvas canvas, RectF dirtyRect);
    }
