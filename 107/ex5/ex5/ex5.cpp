#define fa ios::sync_with_stdio(false); cin.tie(NULL);
#define N 1000050 
#include <iostream>
#include <vector>

using namespace std;

int main()
{
    int in_count = 0;
    vector<int> arr = vector<int>(N);
    cin >> in_count;
    for (int i = 0; i < in_count; i++) {
        int num = 0;
        cin >> num;
        arr.push_back(i);
    }

    return 0;
}
