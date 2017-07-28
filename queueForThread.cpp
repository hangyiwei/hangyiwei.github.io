#include<iostream>
#include<vector>
#include<queue>
#include<thread>
#include<mutex>
#include<Windows.h>

using namespace std;
using std::thread;
using std::cout;

std::mutex mtx;
int b = 50;
void Func_1(queue<int>&v1);
void Func_2(queue<int>&v1);
//void Func_2(queue<int>&v2);
int main()
{

	queue<int>v1;
	for (int i = 0; i < 100; i++)
	{
		v1.push(i);
	}

	thread thrd1(Func_1, v1);
	thread thrd2(Func_2, v1);
	thrd1.join();
	thrd2.join();
	//cout << "en "<< endl;
	system("pause");
		
}
void Func_1(queue<int>&v1)
{


	//std::unique_lock<std::mutex> lck(mtx, std::defer_lock);
	
	while (1)
	{
		mtx.lock();



		//DWORD64 t = GetTickCount();
		b--;
		int v = v1.front();
		v1.pop();
		
		cout << "thread1 全局变量b=" << b << "\t" << "队头=" << v << "\t" << "队列大小=" << v1.size() << endl;
	
		if (b == 0)

		{
			cout << "结束" << endl;
			break;

		}
		mtx.unlock();

		
		//DWORD64 t2 = GetTickCount() - t;
		//cout << t2 << endl;


		
	}

}
void Func_2(queue<int>&v1)
{


	//std::unique_lock<std::mutex> lck(mtx, std::defer_lock);

	while (1)
	{
		mtx.lock();

		b--;

		//DWORD64 t = GetTickCount();
		int v = v1.front();
		v1.pop();


		cout << "thread2 全局变量b=" << b << "\t" << "队头=" << v << "\t" << "队列大小=" << v1.size() << endl;

		if (b == 0)

		{
			cout << "结束" << endl;
			break;

		}
		mtx.unlock();
	}
}