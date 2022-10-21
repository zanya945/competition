#include <iostream>
#include <string>
#define N 1000015
#define qu ios::sync_with_stdio(false); cin.tie(NULL);

using namespace std;
static int B = 0, S = 0, D = 0, L = 0, kind = 0;
static bool b_fl = 0, s_fl = 0, d_fl = 0, l_fl = 0;

void check(string str) {
    for (int i : str) {
        switch (i) {
        case 32:
            if (!l_fl) kind++;
            L++; l_fl = 1;
            break;
        case 33:
            if (!l_fl) kind++;
            L++; l_fl = 1;
            break;
        case 35:
            if (!l_fl) kind++;
            L++; l_fl = 1;
            break;
        case 36:
            if (!l_fl) kind++;
            L++; l_fl = 1;
            break;
        case 37:
            if (!l_fl) kind++;
            L++; l_fl = 1;
            break;
        case 38:
            if (!l_fl) kind++;
            L++; l_fl = 1;
            break;
        case 40:
            if (!l_fl) kind++;
            l_fl = 1;
            L++;
            break;
        case 41:
            if (!l_fl) kind++;
            l_fl = 1;
            L++;
            break;
        case 42:
            if (!l_fl) kind++;
            L++; l_fl = 1;
            break;
        case 43:
            if (!l_fl) kind++;
            L++; l_fl = 1;
            break;
        case 45:
            if (!l_fl) kind++;
            L++; l_fl = 1;
            break;
        case 64:
            if (!l_fl) kind++;
            L++; l_fl = 1;
            break;
        case 94:
            if (!l_fl) kind++;
            L++; l_fl = 1;
            break;
        case 95:
            if (!l_fl) kind++;
            L++; l_fl = 1;
            break;
        }
        if (i >= 97 && i <= 122) {
            if (!s_fl) kind++;
            S++;
            s_fl = 1;
        }
        else if (i >= 65 && i <= 90) {
            if (!b_fl) kind++;
            B++;
            b_fl = 1;
        }
        else if (i >= 48 && i <= 57) {
            if (!d_fl) kind++;
            D++;
            d_fl = 1;
        }
    }
}

int main() {
    qu
        string input = "";
    cout << "請輸入密碼";
    cin >> input;
    check(input);
    bool currect = (kind >= 3) ? true : false;
    cout << "密碼長度: " << input.length() << endl;
    cout << "大寫字母長度: " << B << endl;
    cout << "小寫字母長度: " << S << endl;
    cout << "數字長度: " << D << endl;
    cout << "符號長度: " << L << endl;
    if (currect) {
        cout << "符合密碼規則";
    }
    else {
        cout << "不符合密碼規則";
    }
    return 0;
}
