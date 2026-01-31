using System;

public class GameEvent
{
    private event Action action = delegate { };

    public void Publish()
    {
        action.Invoke();
    }

    public void Add(Action listener)
    {
        action += listener;
    }

    public void Remove(Action listener)
    {
        action -= listener;
    }
}

public class GameEvent<T>
{
    private event Action<T> action = delegate { };

    public void Publish(T arg)
    {
        action.Invoke(arg);
    }

    public void Add(Action<T> listener)
    {
        action += listener;
    }

    public void Remove(Action<T> listener)
    {
        action -= listener;
    }
}
