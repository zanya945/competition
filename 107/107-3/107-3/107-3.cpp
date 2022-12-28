#include <iostream>
#include <unordered_map>
#include <vector>

using namespace std;

unordered_map<int, int> map = unordered_map<int, int>();
string str = "!@#$%^&*()-+_=", input;
bool wrong = false;
int kind = 0, num_len = 0, E_len = 0, e_len = 0, owo_len = 0;
int nfl = 0, Efl = 0, efl = 0, ofl = 0;
void check(string input) {
	for (int i = 0; i < input.length(); i++) {
		if (input[i] >= 65 && input[i] <=90) {
			E_len++;
			Efl = 1;
		}
		else if(input[i] >= 97 && input[i] <= 122){
			e_len++;
			efl = 1;
		}
		else if (input[i] >= 48 && input[i] <=57) {
			num_len++;
			nfl = 1;
		}
		else if (map[input[i]] == 1) {
			owo_len++;
			ofl = 1;
		}
		else {
			wrong = true;
		}
	}
	if (!(ofl + Efl + efl + nfl >= 3)) {
		wrong = true;
	}
}

int main() {
	ios::sync_with_stdio(false); cin.tie(NULL);
	for (int i : str) {
		map[i] = 1;
	}
	cout << "請輸入密碼\n";
	cin >> input;
	if (input.length() >= 8 && input.length() <= 128) {
		check(input);
	}
	else {
		check(input);
		wrong = true;
	}
	cout << "密碼長度 " << input.length() << "\n";
	cout << "大寫英文長度 " << E_len << "\n";
	cout << "小寫英文長度 " << e_len << "\n";
	cout << "數字長度 " << num_len << "\n";
	cout << "符號長度 " << owo_len << "\n";


	if (!wrong) {
		cout << "符合密碼規則";
	}
	else {
		cout << "不符合密碼規則";
	}
}