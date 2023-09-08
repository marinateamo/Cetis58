#include <iostream>
#include <chrono>
#include <thread>

int main() {
    int minutes, seconds;
    std::cout << "Enter the number of minutes: ";
    std::cin >> minutes;

    seconds = minutes * 60;

    while (seconds >= 0) {
        int displayMinutes = seconds / 60;
        int displaySeconds = seconds % 60;
        std::cout << displayMinutes << ":";

        if (displaySeconds < 10) {
            std::cout << "0";
        }

        std::cout << displaySeconds << std::endl;

        std::this_thread::sleep_for(std::chrono::seconds(1));
        seconds--;
    }

    std::cout << "Time's up!\n";
    return 0;
}


