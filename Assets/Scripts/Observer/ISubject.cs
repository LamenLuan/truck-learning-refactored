public interface ISubject // Subject
{
    void Attach(IObserver observer);

    void Dettach(IObserver observer);

    void Notify();
}