using GameStarter.Display;
using Symphony;

namespace GameStarter.Content.Loading;

public abstract class GLContentItem : ContentItem
{
    protected GLContentItem(IContentSource source, object content) : base(source, content)
    {
    }

    protected override void OnContentUpdated(object newContent)
    {
        DisplayManager.LockedGLContext(() =>
        {
            this.DestroyGL();
            this.InitGL(newContent);
        });
    }

    public override void Unload()
    {
        DisplayManager.LockedGLContext(() =>
        {
            this.DestroyGL();
        });
    }

    public unsafe abstract void DestroyGL();
    public unsafe abstract void InitGL(object newContent);
    public abstract bool IsGLInitialized();
}

public abstract class GLContentItem<T> : GLContentItem
{
    public GLContentItem(IContentSource source, T content) : base(source, content)
    {
    }

    public new T Content => (T)base.Content;

    public override void InitGL(object newContent)
    {
        this.InitGL((T)newContent);
    }

    public unsafe abstract void InitGL(T newContent);
}