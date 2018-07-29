#include <stdexcept>
#include <iostream>
#include "native-exceptions-thrower-c-externs.h"

using namespace std;

extern "C" {

	EXPORT void throw_runtime_exception() {
		cout << "Native: throwing a runtime_error..." << endl;
		throw std::runtime_error("Look at me, I'm a runtime_error");
	}

	EXPORT void throw_access_violation_exception() {
		cout << "Native: throwing an access violation..." << endl;
		int* i_pointer;
		int i = 6 + *i_pointer;
		cout << "Native: just printing this so that the copmiler won't optimize 'i' out: " << i << endl;
	}

	EXPORT void throw_floating_point_exception() {
		cout << "Native: throwing a floating point exception..." << endl;
		int g = 3 / 0;
		cout << "Native: just printing this so that the copmiler won't optimize 'g' out: " << g << endl;
	}

}