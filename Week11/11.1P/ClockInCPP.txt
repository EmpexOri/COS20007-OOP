#include <iostream>
#include <iomanip> // For std::setw
#include <thread>
#include <chrono>

class CounterClass {
private:
    int _counter;
    std::string _name;

public:
    CounterClass(std::string name) : _name(name), _counter(0) {}

    std::string GetName() {
        return _name;
    }

    int GetTicks() {
        return _counter;
    }

    void Increment() {
        _counter++;
    }

    void Reset() {
        _counter = 0;
    }
};

class ClockClass {
private:
    CounterClass _secondsCounter;
    CounterClass _minutesCounter;
    CounterClass _hoursCounter;

public:
    ClockClass() : _secondsCounter("Seconds"), _minutesCounter("Minutes"), _hoursCounter("Hours") {}

    void GetTime() {
        _secondsCounter.Increment();
        if (_secondsCounter.GetTicks() >= 60) {
            _secondsCounter.Reset();
            _minutesCounter.Increment();

            if (_minutesCounter.GetTicks() >= 60) {
                _minutesCounter.Reset();
                _hoursCounter.Increment();

                if (_hoursCounter.GetTicks() >= 24) {
                    _hoursCounter.Reset();
                }
            }
        }
    }

    void RunClock() {
        while (true) {
            GetTime();
            PrintTime();
            std::this_thread::sleep_for(std::chrono::seconds(1));
        }
    }

    void PrintTime() {
        std::cout << std::setfill('0'); // Set fill character to '0'
        std::cout << std::setw(2) << _hoursCounter.GetTicks() << ":"
            << std::setw(2) << _minutesCounter.GetTicks() << ":"
            << std::setw(2) << _secondsCounter.GetTicks() << std::endl;
    }
};

int main() {
    ClockClass clock;
    clock.RunClock();  // This will run the clock indefinitely.
    return 0;
}
