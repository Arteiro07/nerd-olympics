import "./layout.scss";

export default function RootLayout({
  children,
}: {
  children: React.ReactNode
}) {
  return (
    <html lang="en">
      <head />
      <body>
      <div className='container'>
        <div className='navigation-bar'>
          <nav>
            <ul>
              <li>
                <a href="#" id="logo" > Logo </a>
              </li>
              <li>
                <a href="about">About </a>
              </li>
              <li>
                <a href="signup">Sign up</a>
              </li>
              <li>
                <a href="players">Players</a>
              </li>
              <li>
                <a href="activities">Activities</a>
              </li>
            </ul>
          </nav>
        </div>  
        {children}
        </div>
      </body>
    </html>
  )
}
