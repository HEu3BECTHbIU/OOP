#include <iostream>
#include <memory>

using namespace std;
class Point
{
private:
    int x;
    int y;
public:
    Point() : x(0), y(0)
    {
        cout << "Конструктор по умолчанию" << endl;
    }
    Point(int x, int y) : x(x), y(y)
    {
        cout << "Конструктор с параметрами" << endl;
    }
    Point(const Point &p): x(p.x), y(p.y)
    {
        cout << "Конструктор копирования" << endl;
    }
    ~Point()
    {
        cout << "Уничтожение Point с атрибутами " << x << " " << y << endl;
    }
    void Print()
    {
        cout << x << " " << y << endl;
    }
};

void Func1(unique_ptr<Point> p)
{
    p->Print();
}
void Func2(unique_ptr<Point> &p)
{
    p = make_unique<Point>(30, 40);
    p->Print();
}

unique_ptr<Point> Func3(unique_ptr<Point> p)
{
    p->Print();
    p = make_unique<Point>(30, 40);
    return move(p);
}

void Func4(shared_ptr <Point> sp)
{
    sp->Print();
}
int main()
{
    setlocale(LC_ALL, "rus");
    unique_ptr<Point> p = make_unique<Point>(10, 20);
    // Func1(p); // ошибка, передавать по значению нельзя
    cout << "Func1:" << endl;
    Func1(move(p));
    cout << endl;
    cout << "Func3:" << endl;
    p = make_unique<Point>(10, 20);
    p = Func3(move(p));
    cout << endl;

    shared_ptr<Point> sp = make_shared<Point>(100, 200);
    cout << "Func4:" << endl;
    Func4(sp);
}
