#include <iostream>

using namespace std;

class Car
{
public:
    virtual void Move() = 0;
    virtual ~Car() {};
};
class SpecialCar : public Car
{
public:
    ~SpecialCar()
    {
        cout << "Деструктор спец. машины\n";
    }

    void Move() override
    {
        cout << "Движение машины специального назначения" << endl;
    }

    void TurnSiren()
    {
        cout << "машина спец. назначения включает сирену" << endl;
    }

    void MoveWithSiren()
    {
        cout << "машина спец. назначения едет без сирены" << endl;
        TurnSiren();
    }

    void StartMoving()
    {
        cout << "машина спец. назначения начинает движение" << endl;
        Move();
    }
};
class PoliceCar : public SpecialCar
{
public:
    ~PoliceCar()
    {
        cout << "Деструктор полицейской машины\n";
    }
    void Move() override
    {
        cout << "Движение полицейской машины" << endl;
    }
    void TurnSiren()
    {
        cout << "полицейская машина использует сирену" << endl;
    }
};
class TransportCar :public Car
{
public:
    void Move() override
    {
        cout << "Движение легковой машины" << endl;
    }
};

void Test2()
{
    // в базовом классе объявлен невиртуальный метод TurnSiren
    // а в классе-потомке объявлен метод с таким же именем 
    //какой метод будет вызываться при обращении к объекту через указатель на базовый класс
    SpecialCar* sp = new SpecialCar();
    sp->TurnSiren();
    delete sp;
    cout << "\n";
    // обращение через указатель на класс-потомок
    SpecialCar* sp2 = new PoliceCar();
    sp2->TurnSiren();
    delete sp2;
    cout << "\n";
}
void Test1()
{
    // в методе MoveWithSiren базового класса вызывается UseSiren, который определен
    // в этом же классе как невиртуальный, у класса-потомка UseSiren переопределен
    SpecialCar* sp = new PoliceCar();
    sp->MoveWithSiren();
    cout << "\n";
    //в методе StartMoving базового класса вызывается Move, который определен
    // в этом же классе как виртуальный, у класса-потомка Move переопределен
    sp->StartMoving();
    cout << "\n";
    delete sp;
}
void Test3()
{
    // в базовом классе объявлен виртуальный метод Move
    // а в классе-потомке объявлен метод с таким же именем 
    //какой метод будет вызываться при обращении к объекту через указатель на базовый класс
    SpecialCar* sp = new SpecialCar();
    sp->Move();
    cout << "\n";
    // обращение через указатель на класс-потомок
    Car* sp2 = new PoliceCar();
    sp2->Move();
    cout << "\n";
    delete sp2;
    delete sp;
}
int main()
{
    setlocale(LC_ALL, "rus");
    //Test1();
    //Test2();
    Test3();
}