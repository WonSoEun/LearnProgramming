using System;

public interface IObserver
{
    void Update(string state); // 상태가 변경되면 호출되는 메서드
}

public class Subject
{
    private List<IObserver> observers = new List<IObserver>();
    private string state; // 주체의 상태


    public void Attach(IObserver observer)  // 옵저버 추가
    {
        observers.Add(observer);
    }


    public void Detach(IObserver observer)  // 옵저버 제거
    {
        observers.Remove(observer);
    }


    public void SetState(string state)  // 상태 변경 및 알림
    {
        this.state = state;
        Notify(); // 상태 변경 후 옵저버들에게 알림
    }


    private void Notify()   // 상태 변경을 옵저버들에게 알림
    {
        foreach (var observer in observers)
        {
            observer.Update(state); // 각 옵저버의 Update 메서드 호출
        }
    }
}

public class ConcreteObserver : IObserver
{
    private string observerState;

    public void Update(string state)
    {
        // 주체에서 메서드 호출(알림받음)하여 옵저버의 상태 업데이트
        observerState = state;
        Console.WriteLine("옵저버의 새로운 상태: " + observerState);
    }
}

public class Program
{
    public static void Main()
    {
        Subject subject = new Subject();  // 주체 객체 생성

        ConcreteObserver observer1 = new ConcreteObserver();  // 옵저버 객체 생성
        ConcreteObserver observer2 = new ConcreteObserver();

        subject.Attach(observer1);  // 옵저버 등록
        subject.Attach(observer2);

        subject.SetState("새로운 상태 1"); // 주체의 상태 변경

        // 상태 변경 후 옵저버들에게 알림이 전달됨
        // 출력: 옵저버의 새로운 상태: 새로운 상태 1
        // 출력: 옵저버의 새로운 상태: 새로운 상태 1
    }
}