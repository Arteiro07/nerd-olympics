import Image from 'next/image';
import about_img from '../../public/hotpot.png';

export default function page() {
  return (
    <div>
        <h1>About</h1>
        <div>
            Nerd olympics is a website where a group of friends compete over a series of inane challenges to see who's the best human among them.
        </div>
        <Image 
          src={about_img}
          alt="about_img"
        />
    </div>
  )
}
