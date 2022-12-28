#include <unordered_map>
#include <vector>
#include <iostream>

using namespace std;

unordered_map<string, vector<string>> check;
unordered_map<string, int> ma;
vector<string> name = vector<string>();
vector<string> stick_name = vector<string>();
unordered_map<string, int> kind = unordered_map<string, int>();
unordered_map<string, vector<string>> map = unordered_map<string, vector<string>>();
int input_count, pl_count, output_count;

void changeo(string stick, string node, int state) {
    if (state == 2) {
        if (ma[map[stick][2]] != 1) {
            if (ma[map[stick][0]] && ma[map[stick][1]]) {
                ma[map[stick][2]] = 1;
                ma[map[stick][1]] = 0;
                ma[map[stick][0]] = 0;
                for (string stick1 : check[map[stick][2]]) {
                    node = map[stick][2];
                    state = kind[node];
                    changeo(stick1, node, state);
                }
            }
        }
    }
    else if(state == 1){
        if (map[stick].size() == 3) {
            if (ma[map[stick][0]] && ma[map[stick][1]]) {
                ma[map[stick][2]] = 1;
                ma[map[stick][1]] = 0;
                ma[map[stick][0]] = 0;
                for (string stick1 : check[map[stick][2]]) {
                    node = map[stick][2];
                    state = kind[node];
                    changeo(stick1, node, state);
                }
            }
        }
        else if (ma[map[stick][1]] != 1) {
            ma[map[stick][1]] = 1;
            ma[node] = 0;
            for (string stick1 : check[map[stick][1]]) {
                node = map[stick][1];
                state = kind[node];
                changeo(stick1, node, state);
            }
        }
    }
}

int main()
{
    ios::sync_with_stdio(false); cin.tie(NULL);
    cout << "鍵入 輸入小圓盤數量及名稱 \n";
    cin >> input_count;
    for (int i = 0; i < input_count; i++) {
        string num; cin >> num;
        name.push_back(num);
        ma[num] = 0;
        kind[num] = 1;
    }
    cout << "鍵入 內部小圓盤數量及名稱 \n";
    cin >> pl_count;
    for (int i = 0; i < pl_count; i++) {
        string num;  cin >> num;
        name.push_back(num);
        ma[num] = 0;
    }
    cout << "鍵入 輸出小圓盤數量及名稱 \n";
    cin >> output_count;
    for (int i = 0; i < output_count; i++) {
        string num;  cin >> num;
        name.push_back(num);
        ma[num] = 0;
    }
    cout << "輸入2-1轉移棒的名稱以及小圓盤\n";
    int con = 1;
    while (con == 1) {
        string node1, node2, output;
        string stick = "";
        cin >> stick >> node1 >> node2 >> output;
        kind[output] = 2;
        stick_name.push_back(stick);
        map[stick].push_back(node1);
        map[stick].push_back(node2);
        map[stick].push_back(output);
        cout << "continue?(1/0)";
        cin >> con;
    }
    con = 1;
    cout << "輸入1-1轉移棒的名稱以及小圓盤\n";
    while (con == 1) {
        string node1, output;
        string stick = "";
        cin >> stick >> node1 >> output;
        stick_name.push_back(stick);
        map[stick].push_back(node1);
        map[stick].push_back(output);
        cout << "continue?(1/0)";
        cin >> con;
        kind[node1] = 1;
        kind[output] = 1;
    }
    cout << "轉移棒與小圓盤關係\n";
    for (auto i : stick_name) {
        cout << i << " :";
        for (auto n : map[i]) {
            cout << " " << n;
        }
        cout << " ";
    }
    cout << "\n小圓盤與轉移棒關係\n";
    for (auto i : name) {
        cout << i << ": ";
        for (auto j : stick_name) {
            for (int x = 0; x < map[j].size(); x++) {
                if (map[j][x] == i) {
                    cout << j << " ";
                    check[i].push_back(j);
                }
            }
        }
    }
    con = 1;
    while (con) {
        cout << "\n鍵入放權杖的圓盤名稱: \n";
        string str = "";
        cin >> str;
        int count = 0, state = kind[str];
        ma[str] = 1;
        cout << "執行前權杖狀況: ";
        for (auto i : name) {
            cout << i << ": " << ma[i] << " ";
        }
        cout << "\n執行轉移棒\n";
        for(string stick1 : check[str]) {
            changeo(stick1, str, state);
        }
        cout << "執行後各權杖狀況: ";
        for (auto i : name) {
            cout << i << ": " << ma[i] << " ";
        }
        cout << '\n';
        cout << "continue?(1/0)";
        cin >> con;
    }
}

