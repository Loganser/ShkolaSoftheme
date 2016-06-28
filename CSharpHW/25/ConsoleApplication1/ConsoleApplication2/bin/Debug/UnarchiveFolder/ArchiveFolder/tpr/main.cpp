#include <iostream>
#include <cstdio>
#include <vector>
#include <cmath>
#include <fstream>
#include <string>
#include <sstream>
#include <limits>
#include <iomanip>
#include <cstdlib>
#include <utility>
using namespace std;
#include "data_table.h"


int main ()
{

	vector <vector <string > > x;
	x.resize(10);
	for (int i=0; i<10; i++) x[i].resize(10);
	Data_table table(x,1,2,3);
	table.Read();
	table.Write();
	table.Middle_val_method();
	table.Write();
	table.Resampling_1();
	table.Write();
	system("pause");
	return 0;
}