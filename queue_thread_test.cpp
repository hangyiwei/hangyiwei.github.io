




#include<iostream>
#include<vector>
#include<queue>
#include<thread>
#include<mutex>
#include<Windows.h>
#include<thread>

using namespace std;
using std::thread;
using std::cout;

std::mutex mtx;
int b = 50;

queue<int>v1;
void Func_1( );
void Func_2( );

int main()
{
	int a ;
	
	for ( int i = 0; i < 100; i++)
	{
		v1.push(i);
	}

	thread thrd1(Func_1 );
	thread thrd2(Func_2 );
	thrd1.join();
	thrd2.join();

	system("pause");
		
}
void Func_1()
{


	
	while (1)
	{
		mtx.lock();
		

		
	
	
		if (b <= 0)

		{
			cout << "����" << endl;
			break;

		}
		b--;
		
		if (v1.size() != 0)
		{
			auto v = v1.front();
			v1.pop();
			
			cout << "thread1 ȫ�ֱ���b=" << b << "\t" << "��ͷ=" << v << "\t" << "���д�С=" << v1.size() << endl;
		}
		else
			break;
		
		
	
	
		mtx.unlock();

		
		
	}
	mtx.unlock();

}


void Func_2()
{

	
	

	while (1)
	{
		mtx.lock();
		if (b <= 0)
		{
			cout << "����" << endl;
			break;

		}
	
		b--;
		if (v1.size() != 0)
		{
			int v = v1.front();
			
			v1.pop();
			
			cout << "thread2 ȫ�ֱ���b=" << b << "\t" << "��ͷ=" << v << "\t" << "���д�С=" << v1.size() << endl;

		}
		
		




	
		mtx.unlock();
	}
	mtx.unlock();
}
	
	

	


