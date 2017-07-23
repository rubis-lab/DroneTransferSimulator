#include <iostream>
#include <fstream>
#include <string>
#include <vector>

using namespace std;

int main()
{
	FILE *fr;

	ifstream file("data.csv");
	vector< vector<float> > data;
	string line;
	fopen_s(&fr, "data.csv", "r");

	while (getline(file, line))
	{
		float a, b, c, d, e, f;
		vector <float> newline;
		fscanf_s(fr, "%f %f %f %f %f %f\n", &a, &b, &c, &d, &e, &f);

		newline.push_back(a);
		newline.push_back(b);
		newline.push_back(c);
		newline.push_back(d);
		newline.push_back(e);
		newline.push_back(f);
		data.push_back(newline);

	}
	fclose(fr);
	return 0;
}


/*
void main()
{
	ifstream file;
	vector< vector<double> > data;
	vector <double> lineVec;
	string line;
	double ff;
	int i = 0;

	file.open("data.txt");
	while (getline(file, line))
	{
		string f;
		stringstream ss(line);
		while (getline(ss, f, ','))
		{
			ff = stod(f);
			lineVec.push_back(ff);
		}

		data.push_back(lineVec);
		lineVec.clear();
	}
	cout << i << endl;
	cout << "size:" << int(data.size()) << endl;
	cout << int(data[0].size()) << endl;

	file.close();
}
*/