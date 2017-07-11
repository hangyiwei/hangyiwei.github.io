#include<mutex>
#include<iostream>
#include<thread>

void Fun_1(unsigned int  &num_1);
void Fun_2(unsigned int  &num_1);
std::mutex m;


int main()
{

	unsigned int num_1 = 0;
	
	std::thread thrd_1(Fun_1,std::ref(num_1));
	std::thread thrd_2(Fun_2, std::ref(num_1));
	
	thrd_1.join();
	
	thrd_2.join();
	

}
void Fun_1(unsigned int &num_1) {
	while (1)
	{
		std::lock_guard<std::mutex> mtx_locker(m);
		num_1++;
		if (num_1 < 1000)
			std::cout << num_1 <<" 正在执行线程1\n" << std::endl;


		else
			break;
	}
}
void Fun_2(unsigned int &num_1) {

	while (1)
	{
		std::lock_guard<std::mutex> mtx_locker(m);
		num_1++;
		if (num_1 < 1000)
			std::cout << num_1 <<"正在执行线程2\n"<< std::endl;
		else
			break;

	}
}