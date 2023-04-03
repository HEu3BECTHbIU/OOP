#include <iostream>
#include <ctime>
#include<random>
using namespace std;

class Car
{
public:
    virtual string Classname()
    {
        return "Car";
    }
    virtual bool IsA(const string &who)
    {
        return who == "Car";
    }
    virtual ~Car() {};
};
class SpecialCar : public Car
{
public:
    ~SpecialCar()
    {
        // cout << "Деструктор спец. машины\n";
    }

    string Classname() override
    {
        return "SpecialCar";
    }
    bool IsA(const string& who) override
    {
        return ((who == "SpecialCar") || Car::IsA(who));
    }
    virtual void TurnSiren()
    {
        cout << "машина спец. назначения включает сирену" << endl;
    }
};
class PoliceCar : public SpecialCar
{
public:
    ~PoliceCar()
    {
         //cout << "Деструктор полицейской машины\n";
    }
    string Classname() override
    {
        return "PoliceCar";
    }
    bool IsA(const string& who) override
    {
        return ((who == "PoliceCar") || SpecialCar::IsA(who));
    }
    void TurnSiren() override
    {
        cout << "полицейская машина включает сирену" << endl;
    }
};
class TransportCar :public Car
{
public:
    ~TransportCar()
    {
        //cout << "Деструктор легковой машины\n";
    }
    string Classname() override
    {
        return "TransportCar";
    }
    bool IsA(const string& who) override
    {
        return ((who == "TransportCar") || Car::IsA(who));
    }
};

Car* InitializeArray()
{
    Car* carpark[10];
    for (int i = 0; i < 10; i++)
    {
        int elem = rand() % 3;
        if (elem == 0)
        {
            carpark[i] = new SpecialCar();
        }
        if (elem == 1)
        {
            carpark[i] = new TransportCar();
        }
        if (elem == 2)
        {
            carpark[i] = new PoliceCar();
        }
    }
    return carpark[10];
}
void Test1() // используя classname
{
    Car* carpark[10];
    for (int i = 0; i < 10; i++)
    {
        int elem = rand() % 3;
        if (elem == 0)
        {
            carpark[i] = new SpecialCar();
        }
        if (elem == 1)
        {
            carpark[i] = new TransportCar();
        }
        if (elem == 2)
        {
            carpark[i] = new PoliceCar();
        }
    }
    for (int i = 0; i < 10; i++)
    {
        if (carpark[i]->Classname() == "SpecialCar" || carpark[i]->Classname() == "PoliceCar")
        {
            static_cast<SpecialCar*>(carpark[i])->TurnSiren();
        }
    }
    for (int i = 0; i < 10; i++)
    {
        delete carpark[i];
    }
}

void Test2() // используя метод IsA
{
    Car* carpark[10];
    for (int i = 0; i < 10; i++)
    {
        int elem = rand() % 3;
        if (elem == 0)
        {
            carpark[i] = new SpecialCar();
        }
        if (elem == 1)
        {
            carpark[i] = new TransportCar();
        }
        if (elem == 2)
        {
            carpark[i] = new PoliceCar();
        }
    }
    for (int i = 0; i < 10; i++)
    {
        if (carpark[i]->IsA("SpecialCar"))
        {
            static_cast<SpecialCar*>(carpark[i])->TurnSiren();
        }
    }
    for (int i = 0; i < 10; i++)
    {
        delete carpark[i];
    }
}

void Test3() // безопасное приведение dynamic_cast
{
    Car* carpark[10];
    for (int i = 0; i < 10; i++)
    {
        int elem = rand() % 3;
        if (elem == 0)
        {
            carpark[i] = new SpecialCar();
        }
        if (elem == 1)
        {
            carpark[i] = new TransportCar();
        }
        if (elem == 2)
        {
            carpark[i] = new PoliceCar();
        }
    }
    for (int i = 0; i < 10; i++)
    {
        SpecialCar* sp = dynamic_cast<SpecialCar*>(carpark[i]);
        if (sp != NULL)
        {
            sp->TurnSiren();
        }
    }
    for (int i = 0; i < 10; i++)
    {
        delete carpark[i];
    }
}

int main()
{

    srand(time(NULL));
    setlocale(LC_ALL, "rus");
    // Test1();
    //Test2();
    Test3();

}