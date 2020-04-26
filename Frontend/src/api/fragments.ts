export const Fragments = {
  projectDetail: `
    id
    name
    description
    url
    categories {
      category
    }
    cardImage {
      id
      description
      url
    }
    bannerImage {
      id
      description
      url
    }
    descriptiveImage {
      id
      description
      url
    }
    owner {
      fullName
      firstName
      lastName
    }
    tags {
      tag {
        name
      }
    }
    goal
    start
    end
    status
    target
    proposal
    remainingTime
    remainingTimeUserFriendly
    canSendProjectEmail
    displayPriority
    isActive
    isComingSoon
    isClosed
    isSuccessfull
    isFailed
    totalParticipants
    percentage
    numberProjectEmailsSent
  `,
};
