#include<iostream>
#include<vector>
#include<queue>
#include<thread>
#include<mutex>
#include<Windows.h>

using namespace std;
using std::thread;

std::mutex mtx;
void Func_1(queue<int>&v1);
//void Func_2(queue<int>&v2);
int main()
{
	int i = 0;
	queue<int>v1;
	for (;i < 100; i++)
	{
		v1.push(i);
	}
	
	thread thrd1(Func_1, v1);
	thread thrd2(Func_1, v1);
	thrd1.join();
	thrd2.join();
    return 0;

}
void Func_1(queue<int>&v1)
{
	
	int b = 17;
	std::unique_lock<std::mutex> lck(mtx,std::defer_lock);
	
	while (1)
	{

		lck.lock();
		//DWORD64 t = GetTickCount();
		int v = v1.front();
		v1.pop();
		cout << v << "\n" << endl;

		b--;
		//DWORD64 t2 = GetTickCount() - t;
		//cout << t2 << endl;
		lck.unlock();

		if (b == 0)	break;
		
	}
}
