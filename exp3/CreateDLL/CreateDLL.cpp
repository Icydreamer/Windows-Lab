#include "pch.h"
#include "CreateDLL.h"

int __stdcall Fac(int x)
{
	return x == 0 ? 1 : x * Fac(x - 1);
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