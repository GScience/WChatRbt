
#include <Windows.h>
#include <string>

using namespace WChatRbtLib;

int main()
{
	System::String ^ uuid = WChatRbtLib::WChat::GetUUID();

	WChatRbtLib::WChat::GetLoginQRCode(uuid);

	System::String ^ getCookieURL = WChatRbtLib::WChat::WaitForLoginAndGetCookie(uuid);

	WChatRbtLib::WChat::login(getCookieURL);

	while (true);
}