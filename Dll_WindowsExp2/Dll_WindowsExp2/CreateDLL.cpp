#include "CreateDLL.h"
#include "pch.h"
#include <cstdlib>
#include <iostream>
using namespace std;
int  __stdcall plus3(int a, int b, int c)
{
	return a + b + c;
}
int __stdcall mul2(int a, int b)
{
	return a * b;
}
char* __stdcall unionString(char* a, char* b)
{
	int n = strlen(a), m = strlen(b), cnt = 0;
	char* c = (char*)malloc(50*sizeof(char));
	for (int i = 0; i < n; i++) if (a[i] != '\"') c[cnt++] = a[i];
	for (int i = 0; i < m; i++) if (b[i] != '\"') c[cnt++] = b[i];
//	static char* ret = new char[25];
	//memset(ret, 0, sizeof(ret));
	//for (int i = 0; i < cnt; i++) ret[i] = c[i]; ret[cnt] = '\0';
	c[cnt] = '\0';
	return c;
}
int __stdcall Fac(int x) 
{ 
	if (x < 0) {
		cout << "参数不合法" << endl;
		return -1;
	}
	else {
		return x == 0 ? 1 : x * Fac(x - 1);
	}
}

int __stdcall subtract(int a, int b)
{
	if (a >= b) {
		return a - b;
	}
	else {
		return b - a;
	}
}