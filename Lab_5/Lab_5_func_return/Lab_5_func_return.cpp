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
    Base(const Base& obj)
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

Base Func1()
{
    cout << "\nFunc1:" << endl;
    Base obj;
    return obj;
}

Base *Func2()
{
    cout << "\nFunc2:" << endl;
    Base obj;
    return &obj;
}

Base &Func3()
{
    cout << "\nFunc3:" << endl;
    Base obj;
    return obj;
}
Base Func4()
{
    cout << "\nFunc4:" << endl;
    Base* obj = new Base(); // утечка памяти, т.к *obj никто не удаляет
    return *obj;
}

Base *Func5()
{
    cout << "\nFunc5:" << endl;
    Base* obj = new Base();
    return obj;
}
Base &Func6()
{
    cout << "\nFunc6:" << endl;
    Base* obj = new Base();
    return *obj;
}
void Test3()
{
    {
        Base base = Func1();
        base.foo();
    }
    {
        Base* base2 = Func2();
        base2->foo(); // UB - обращение к методу объекта, которого уже не существует
        // delete base2 // крашнет программу, т.к объект уже удален
    }
    {
        Base &base3 = Func3();
        base3.foo(); // UB - обращение к методу объекта, которого не существует
    }
    {
        Base base4 = Func4();
        base4.foo();
    }
    {
        Base *base5 = Func5();
        base5->foo();
        delete base5;
    }
    {
        Base &base6 = Func6();
        base6.foo();
        delete& base6;
    }
}

void Test4()
{

}
int main()
{
    setlocale(LC_ALL, "rus");
    //Test1();
    //Test2();
    Test3();
}