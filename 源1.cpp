#define _CRT_SECURE_NO_WARNINGS  

#include <iostream>
#include "opencv2/opencv.hpp"
#include <stdio.h>
#include "opencv2/imgproc.hpp"
#include<opencv2\opencv.hpp>

using namespace std;
using namespace cv;



#define NUM 192

int main()

{

	string img_name;
	string img_name2;
	//Rect
	char c[100];
	char c2[100];
	for (int i = 1; i <= NUM; i++)
	{	sprintf_s(c, "%d", i);
	string str1(&c[0], &c[strlen(c)]);
	img_name = "E:\\Photo\\1 (" + str1 + ")" + ".jpg";
	img_name2 = "E:\\Photo\\1000" + str1  + ".jpg";
	strcpy(c2, img_name2.c_str());
	cout << img_name << endl;

	Mat pImg = imread(img_name);
	namedWindow("IMG");
	imshow("IMG", pImg);
	
	
	cvSaveImage(c2, &IplImage(pImg));
	waitKey(50);
	}
	
	return 0;
}






