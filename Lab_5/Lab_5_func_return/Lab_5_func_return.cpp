#include <iostream>

using namespace std;

class Base
{
public:
    Base()
    {
        cout << "Конструктор Base по умолчанию" << endl;
    }
    Base(Base *obj)
    {
        cout << "Констуктор Base от указателя" << endl;
    }
    Base(Base& obj)
    {
        cout << "Констуктор копирования Base" << endl;
    }
    virtual ~Base()
    {
        cout << "Деструктор Base" << endl;
    }
    void foo()
    {
        cout << "Base::foo" << endl;
    }
};
class Desc: public Base
{
public:
    Desc()
    {
        cout << "Конструктор Desc по умолчанию" << endl;
    }
    Desc(Desc* obj)
    {
        cout << "Констуктор Desc от указателя" << endl;
    }
    Desc(Desc& obj)
    {
        cout << "Констуктор копирования Desc" << endl;
    }
    ~Desc()
    {
        cout << "Деструктор Desc" << endl;
    }
    void foo()
    {
        cout << "Desc::foo" << endl;
    }
};

void func1(Base obj)
{
    obj.foo();
    Desc* c = dynamic_cast<Desc*>(&obj);
    if (c != NULL)
    {
        c->foo();
    }
}

void func2(Base *obj)
{
    obj->foo();
    Desc *c = dynamic_cast<Desc*>(obj);
    if (c != NULL)
    {
        c->foo();
    }
}

void func3(Base &obj)
{
    obj.foo();
    Desc *c = dynamic_cast<Desc*>(&obj);
    if (c != NULL)
    {
        c->foo();
    }
}

void Test1()
{
    // статический объект Base
    Base obj1;
    cout << "func1:" << endl;
    func1(obj1);
    cout << "func2:" << endl;
    func2(&obj1);
    cout << "func3:" << endl;
    func3(obj1);
}
void Test2()
{
    // динамический объект Desc
    Desc *obj1 = new Desc();
    cout << "func1:" << endl;
    func1(*obj1);
    cout << "func2:" << endl;
    func2(obj1);
    cout << "func3:" << endl;
    func3(*obj1);
    delete obj1;
}

int main()
{
    setlocale(LC_ALL, "rus");
    //Test1();
    Test2();
    //Test3();
}