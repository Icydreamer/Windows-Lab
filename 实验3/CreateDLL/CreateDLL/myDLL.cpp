#include "pch.h"
#include "myDLL.h"
#include <iostream>
using namespace std;
int power(int a)
{
	if (a < 0) {
		cout << "power:参数不合法";
		return -1;
	}
	int temp = 1;
	while (a > 0) {
		temp *= a;
		a--;
	}
	return temp;
}
int subtract(int a, int b)
{
	if (a >= b)
		return a - b;
	else
		return b - a;
}