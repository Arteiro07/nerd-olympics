import "./layout.scss";
import { AiFillHome } from 'react-icons/ai';
import Link from "next/link";


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
                  <Link href="/" > <AiFillHome/> </Link>
                </li>
                <li>
                  <Link href="/about">About </Link>
                </li>
                <li>
                  <Link href="/signup">Sign up</Link>
                </li>
                <li>
                  <Link href="/players">Players</Link>
                </li>
                <li>
                  <Link href="/activities">Activities</Link>
                </li>
              </ul>
            </nav>
          </div> 
          <div className="content">
            {children}
          </div> 
        </div>
      </body>
    </html>
  )
}
